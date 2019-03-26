namespace KhufuServer

open MongoDB.Bson
open MongoDB.Driver
//open MongoDB.Driver.Builders
open MongoDB.FSharp
open KhufuServer.WorkForcePlanning.Entities

module TicketDocumentDBAdapter =

    [<Literal>]
    let ConnectionString = "mongodb://khufucosmosdb:LTGXrYWzRjU6fWgiDcizMSnZXYV0wsgxzNWSVyznCq5GaDU3aSs7hM1AObHXcYpaEYIyMO327jVDNcpysuJxwA==@khufucosmosdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb"

    [<Literal>]
    let DbName = "Tickets"

    [<Literal>]
    let CollectionName = "TicketsList"

    let client         = MongoClient(ConnectionString)
    let db             = client.GetDatabase(DbName)
    let testCollection = db.GetCollection<Ticket>(CollectionName)
              
    // Create 

    // Single Creation
    let create ( ticket : Ticket ) = 
        testCollection.InsertOne(ticket)
        ticket
    // Read 

    // Read Based On Id 
    let readOnId ( id : BsonObjectId ) = 
        testCollection.Find(fun x -> x.Id = id).ToEnumerable()

    // Read All 
    let readAll =
        testCollection.Find(Builders.Filter.Empty).ToEnumerable()        
        


    
    