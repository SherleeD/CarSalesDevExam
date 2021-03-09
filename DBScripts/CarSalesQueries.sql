select * from [dbo].[VehicleTypes]
select * from [dbo].[VehicleProperties]
select * from [dbo].[VehicleTypeProperties]


select  p.VehicleTypePropertyId, t.VehicleTypeName, vp.VehiclePropertyName
  from [dbo].[VehicleTypeProperties] p 
  left outer join [dbo].[VehicleProperties] vp 
    on  vp.VehiclePropertyId = p.VehiclePropertyId
  left outer join [dbo].[VehicleTypes] t
    on t.VehicleTypeId = p.VehicleTypeId
 where p.VehicleTypeId = 1

select * from [dbo].[Vehicles]
select * from [dbo].[VehicleOtherProperties]