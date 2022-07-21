use EVE-db

select * from BusInfos
select * from BusDrivers
select * from BusDrivers_BusInfos

insert into BusInfos values ('Photo', 'Small bus', 'Pershkrim i Bus', convert(datetime, '5/11/2021 11:01:01 AM'), convert(datetime, '5/19/2021 11:30:00 AM'), 19.99, 10)
insert into BusInfos values ('https://belairelimo.com/wp-content/uploads/2018/01/Motor-Coach.png', 'Motor Coach', 'Another description', convert(datetime, '5/11/2021 11:01:01 AM'), convert(datetime, '5/19/2021 11:30:00 AM'), 4.99, 1)
insert into BusInfos values ('https://3gz8cg829c.execute-api.us-west-2.amazonaws.com/prod/image-renderer/16x9/full/1015/center/80/d0b63c88-feaa-451b-b198-f9ca4ecbd090-large16x9_6PWEBUSDRIVERSHORTAGEPKG.transfer_frame_3668.png', 'School bus', 'Pershkrim', convert(datetime, '5/11/2021 11:01:01 AM'), convert(datetime, '5/19/2021 11:30:00 AM'), 4.99, 1)
insert into BusInfos values ('https://www.motivps.com/wp-content/uploads/2020/05/Motiv-EPIC-E450-Champion-Shuttle-Masked.png', 'Shuttle bus', 'Pershkrim', convert(datetime, '5/11/2021 11:01:01 AM'), convert(datetime, '5/19/2021 11:30:00 AM'), 9.99 , 1)
insert into BusInfos values ('https://media.tacdn.com/media/attractions-splice-spp-674x446/06/6c/1f/9d.jpg', 'Minibus', 'Pershkrim', convert(datetime, '5/11/2021 11:01:01 AM'), convert(datetime, '5/19/2021 11:30:00 AM'), 10.99, 1)
insert into BusInfos values ('https://previews.123rf.com/images/trevorbenbrook/trevorbenbrook1611/trevorbenbrook161100198/66049219-public-transport-single-decker-bus-ipwich-suffolk.jpg', 'Single-Decker bus', 'Pershkrim', convert(datetime, '5/11/2021 11:01:01 AM'), convert(datetime, '5/19/2021 11:30:00 AM'), 12.99, 1)

insert into BusDrivers values ('Picture', 'Filan Fisteku', 'Bus driver i mire')
insert into BusDrivers values ('https://www.gannett-cdn.com/presto/2019/12/06/PNAS/ff2d50c2-eafd-44d8-abc1-5af3c590374c-NAS-SEASON_TO_GIVE-_BUS_DRIVER-02.jpg', 'Filan Fisteku', 'Bus driver i mire')
insert into BusDrivers values ('https://www.usnews.com/dims4/USNEWS/d60ba93/2147483647/crop/2000x1313%2B0%2B0/resize/640x420/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2Fd0%2F30%2F0ad9cfae4715bad5c81f96c93112%2F190219-busdriver-stock.jpg', 'Filan Fisteku', 'Bus driver i mire')
insert into BusDrivers values ('https://upload.wikimedia.org/wikipedia/commons/8/86/Driver_Dave_Marshall_The_Friendly_Bus_Driver.jpg', 'Filan Fisteku', 'Bus driver i mire')
insert into BusDrivers values ('https://nwbus.com/wp-content/uploads/2020/11/Bus-Driver-Hiring-Tips-1200x800.jpg', 'Filan Fisteku', 'Bus driver i mire')
insert into BusDrivers values ('https://www.metroline.co.uk/sites/metroline.co.uk/files/Driver%202016%20%2844%29.jpg', 'Filan Fisteku', 'Bus driver i mire')

insert into BusDrivers_BusInfos values (1, 1)
insert into BusDrivers_BusInfos values (2, 2)
insert into BusDrivers_BusInfos values (3, 3)
insert into BusDrivers_BusInfos values (1, 3)
insert into BusDrivers_BusInfos values (4, 4)
insert into BusDrivers_BusInfos values (5, 5)
insert into BusDrivers_BusInfos values (6, 6)
insert into BusDrivers_BusInfos values (2, 6)