# Hoff The Record


## Requirements
- Must be able to see a report
    - Who got Hoffed
    - Who did the Hoffin'
    - When It Occurred
    - Image used
- A person cannot be hoffed more then once within a minute
- If a Person if Hoffed More then once in 5 minutes then they are placed on "Baywatch" status until they Hoff someone else



## How to Run Locally
- dotnet tool install --global dotnet-ef


## TODO
- Input validation on the command
- validation in the handler
- custom error numbers
- custom exceptions
- Abstract time for testing
- Implement events (mediatr publications)
- createdAt endpoints 

## Axioms
- Tell Don't Ask
    - send a command, not a request. commands are valid
- Extreme Ownership


## Software Promise Land Wish List

- Vertical Features
- Vertical Slicing
- Structured Logging
- Expressive Code
    - CQRS
        - Mediatr for C#
        - Mediatr for typescript as well
    - Verb Based objects
        - Domain Models are an exception
- Immutable Objects that can only be instantiated in a valid state
    - embrace of exceptions
- removal of Generic Repository Pattern in favor of interacting directly with context in data layer
- Async/Await
