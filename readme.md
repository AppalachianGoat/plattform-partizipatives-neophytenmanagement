# Initial setup
1. Install .NET 7.0 SDK
1. Install Node.js 20.11.1

## Running the project
1. Start the docker container with `docker compose up -d`
2. Run migrations with `dotnet ef database update`
3. Have fun!

# User Roles

- Farmer: Manages land and requires help in dealing with invasive species
- Helper: Individuals or organizations that wish to help farmers in dealing with invasive species

# Data models
- User:
    - Id:
    - Role: One of [Farmer, Helper]
    - Email: Email of the user
    - Password: Hashed password of the user
    - FirstName: First name of the user
    - LastName: Last name of the user

- FarmerHelpRequest: contains all details about the farmer's request for help
    - Id:
    - OwnerId: Reference to the User who created the offer
    - Location: Address of the farm text local and coordinates (acquired from some external api)
    - WorkVolume: The amount of work to be done in half day increments
    - NumberOfHelpers: The number of people that the farmer is willing to welcome
    - InvasiveSpeciesTypes: List of invasive species that the farmer wishes to remove

- HelperHelpOffer: Contains all the details about the helpers offer to help farmers
    - Id:
    - OwnerId: Reference to the User who created the offer
    - Location: Address around which the helper wishes to find work
    - DistanceFromLocation: Distance in km within which the helper is willing to travel
    - WorkVolume: The amount of work to be done in half day increments
    - NumberOfHelpers: The number of people that the farmer is willing to welcome

- Negotiation: Contains the status of a negotiation between a Farmer and a Helper
    - Id:
    - DateCreated: Date when the negotiation was created
    - InitiatedByUser: Reference to the User who initiated the negotiation
    - FarmerHelpRequest: reference to the FarmerHelpRequest subject to negotiation
    - HelperHelpOffer: reference to the HelperHelpOffer subject to negotiation
    - FarmerStatus: negotiation approval status on the side of the farmer one of [PENDING, ACCEPTED, REJECTED]
    - HelperStatus: negotiation approval status on the side of the farmer one of [PENDING, ACCEPTED, REJECTED]

- InvasiveSpeciesType:
    - Id:
    - Name: Name of the invasive species
    - Description: Description of the invasive species
    - ImageUrl: URL to an image of the invasive species
