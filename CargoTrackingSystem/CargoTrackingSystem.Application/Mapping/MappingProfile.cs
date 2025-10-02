using AutoMapper;
using CargoTrackingSystem.Application.Features.Customers.Commands.Add;
using CargoTrackingSystem.Application.Features.Customers.CustomerUpdate;
using CargoTrackingSystem.Application.Features.Customers.Queries.GetAll;
using CargoTrackingSystem.Application.Features.Customers.Queries.GetById;
using CargoTrackingSystem.Application.Features.Shipments.Commands.Add;
using CargoTrackingSystem.Application.Features.Shipments.Commands.Update;
using CargoTrackingSystem.Application.Features.Shipments.Queries.GetById;
using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Add;
using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Commands.Update;
using CargoTrackingSystem.Application.Features.ShipmentStatusHistories.Queries.GetById;
using CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Add;
using CargoTrackingSystem.Application.Features.ShipmentTransfers.Commands.Update;
using CargoTrackingSystem.Application.Features.ShipmentTransfers.Queries.GetById;
using CargoTrackingSystem.Application.Features.Warehouses.Commands.Add;
using CargoTrackingSystem.Application.Features.Warehouses.Commands.Update;
using CargoTrackingSystem.Application.Features.Warehouses.Queries.GetById;
using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer mappings
            CreateMap<CustomerAddCommand, Customer>();
            CreateMap<CustomerUpdateCommand, Customer>();
            CreateMap<Customer, CustomerGetByIdDto>();

            // Shipment mappings
            CreateMap<ShipmentAddCommand, Shipment>();
            CreateMap<ShipmentUpdateCommand, Shipment>();
            CreateMap<Shipment, ShipmentGetByIdDto>();

            // ShipmentStatusHistory mappings
            CreateMap<ShipmentStatusHistoryAddCommand, ShipmentStatusHistory>();
            CreateMap<ShipmentStatusHistoryUpdateCommand, ShipmentStatusHistory>();
            CreateMap<ShipmentStatusHistory, ShipmentStatusHistoryGetByIdDto>();

            // ShipmentTransfer mappings
            CreateMap<ShipmentTransferAddCommand, ShipmentTransfer>();
            CreateMap<ShipmentTransferUpdateCommand, ShipmentTransfer>();
            CreateMap<ShipmentTransfer, ShipmentTransferGetByIdDto>();

            // Warehouse mappings
            CreateMap<WarehouseAddCommand, Warehouse>();
            CreateMap<WarehouseUpdateCommand, Warehouse>();
            CreateMap<Warehouse, WarehouseGetByIdDto>();
        }
    }
}
