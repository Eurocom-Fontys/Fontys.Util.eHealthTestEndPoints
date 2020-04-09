# Fontys Eurocom eHealth Testing Environment
A small test API for Fontys Students to build testimplementations against our INR and Medicine Dispensers. These services use made-up and randomly generated data to provide a base set to work on.

## Client endpoints
Whith the Clients endpoint you can retrieve a list of clients in the system. This list is a "fixed" list, meaning that the data and identifiers are equal on each request.

### ClientGetAll
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/clients/

Gets a list of all clients in the system

### ClientGetByID
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/clients/{id}/

Get a specific client based on the {id} token


## INR endpoints
Retrieve details about INR devices and their measurements. The list of INR devices is fixed and will always yield the same results. The measurements are dynamicly generated based on the client and INR device settings.

### INRGetAll
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/inr/

Get all INR devices in the system, including the client record associated to the device.

### INRGetByID
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/inr/{id}/

Get a specific INR device in the system, including the client record associated to the device. The {id} parameter identifies the device.

### INRGetMeasurementsByDeviceID
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/inr/{deviceID}/measurements/

Get the measurements from a certain device. This is a generated list and will be different on each request. The {deviceID} parameter is used to determine the device to get the data from.

## Medicine Dispenser endpoints
Retrieve details about the medicine dispensers and the events happening with these devices. The list of devices is fixed and will always yield a fixed set of data. The events are dynamically generated on each request and will vary.

### MedicineDispenserGetAll
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/medicinedispenser/
Get a list of all dispensers in the system with their associated client record.

### MedicineDispenserGetByID
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/medicinedispenser/{id}/

Get a specific dispenser (identified with the {id} parameter) and the associated client record.

### MedicineDispenserEventsByDeviceID
[GET] https://eurocomfontyshealthservice.azurewebsites.net/api/medicinedispenser/{deviceID}/events/

Get the events for a given dispenser (via the {deviceID} parameter). The events will indicate when the medicines were offered and if/when they were taken.
