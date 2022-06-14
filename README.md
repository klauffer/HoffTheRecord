# HoffTheRecord
HoffTheRecord is a coding kata with the purpose of being a representative of what I think is a good architecture. I will update this repository over time in an attempt to continue to refine the simple domain space to its cleanest and most expressive form.

## What is the Domain?
My current work place has a tradition of posting David Hasselhoff images on a coworker's unlocked machine while they are not present. Its a good fun way to help enforce security policy.

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
- custom error numbers?
- custom exceptions
- structured logging
- Implement events (mediatr publications)
- createdAt endpoints 

## Axioms
- Tell Don't Ask
    - send a command, not a request. commands are valid
- Extreme Ownership
    - Principle 1: Extreme Ownership
    - Principle 2: Not bad teams, bad leaders
    - Principle 3: Be a Believer
    - Principle 4: Check the Ego
    - Principle 5: Cover and Move
    - Principle 6: Keep it Simple
    - Principle 7: Prioritize and Execute
    - Principle 8: Decentralize Command
    - Principle 9: Plan
    - Principle 10: Leading Up the Chain of Command
    - Principle 11: Act Decisively
    - Principle 12: Discipline Equals Freedom
- Test Behaviour Not Implementation
    - when testing a code library, it is much easier to see the API to your library. It's the public methods. Its clear that to test the behaviour of your library instead of its implementation that you send input into the public methods. However in systems that are more complicated, say a website, we have many libraries of code. Each with their own public API. its less obvious what testing behaviour means in this case. I purpose that you look at your website as a whole. In this case I am treating the entire server side as a single system with one API. The HTTP API that is. Just like with the simple case of a single library, I recomend sending input into the public HTTP methods. Testing the behaviour not the implementation.
- SOLID
    - Single Responsibility
    - Open/Close
- DateTime is IO treat it as such with abstraction



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
