namespace KhufuServer.WorkForcePlanning.Entities

open MongoDB.Bson

[<CLIMutable>]
type Ticket =

    {
        Id: BsonObjectId
        Title : string
        Discipline : string
        ProjectName : string
        Grade : string
        ProjectRole : string
        Priority : string
        NumberOfPositions : int32
        Recruiter : string
    }