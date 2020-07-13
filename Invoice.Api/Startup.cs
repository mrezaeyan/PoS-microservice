using AutoMapper;
using EventContract;
using Invoice.Api.EventHandlers;
using Invoice.Api.ObjectMapping;
using Invoice.Domain.Interfaces;
using Invoice.Infrastructure;
using MediatR;
using MessageBroker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoContext;

namespace Invoice.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMediatR(typeof(Startup));
            
            services.AddScoped(typeof(MongoDbContext));
            services.AddSingleton(typeof(MongoDbEventContext));
            services.AddScoped(typeof(IMongoEventRepository<>), typeof(MongoEventRepository<>));
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

            services.Configure<EventSourceDatabaseSettings>(
                Configuration.GetSection(nameof(EventSourceDatabaseSettings)));

            services.AddSingleton<IEventSourceDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<EventSourceDatabaseSettings>>().Value);

            services.AddEventBusRabbitMq(ops =>
            {
                ops.HostName = "localhost";
                ops.UserName = "guest";
                ops.Password = "guest";
                ops.RetryCount = 5;
                ops.QueueName = "POS_Events";
                ops.BrokerName = "EventBus";
            });
            services.AddTransient<PaymentCreatedEventHandler>();
            services.AddTransient<ProductUpdatedEventHandler>();
            
            services.AddControllers();
            
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PaymentCreatedEvent, PaymentCreatedEventHandler>();
            eventBus.Subscribe<ProductUpdatedEvent, ProductUpdatedEventHandler>();
        }
    }
}