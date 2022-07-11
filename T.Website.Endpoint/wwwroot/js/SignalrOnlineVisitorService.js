
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/onlinevisitorhub")
    .build();

connection.start();