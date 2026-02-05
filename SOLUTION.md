# Solution Design

## Overview

THis is just brief overview of the architecture and design I used

## Architecture

I used a mixture of clean architure and vertical architecture design for the solution as it's what I'm familiar with and keeps project structure well organised.

The solution contains 4 layers:

Infrastructure - Contians persitance/Repo logic + infrastructure services

Domain - Contains Entity logic

Application - All the business rules/logic

API - Client

There is also a unit test project with some application layer testing.

## Design Decisions

Overall I chose raw C# and tried to keep libraries to minimal, also partly due to it being a spec requirement.

I could have used libraries for few things, but did not feel the need to on such a small scale solution.

I felt it was trade-off of convenience vs doing something and understanding it.

Did not really measure performace tradeoffs for some decisions yet.

## Implementation Details

### Infrastructure

Used standard Persitance/Repository pattern, with a generic base repository with CRUD logic.

I did not use an ORM only in memory. I may have misunderstand part of the requirements but only saw afterwards it was allowed.

This also contains logic for a generic in memory caching service used. Just a simple setting and and retrieval on an in memory dictionary.

### Domain

Contains the 2 required entities used throughout this solution.

### Application

This where the bulk of the logic lives.

To handle the CRUD and search funtionality I used the CQRS pattern, as I find this to be much cleaner and well defined than "repo/services"

To make things even more claener and avoid repition, I could have used MediatR library, but again chose not to keep things as minimal as possible.

As required, all dto's are records.

For the search I used simple custom linq extension that takes in search term and predicate and returns the comparison on it.

For the correct tree structure of categories, I used a quick recursion emthod to loop through categories to map out parent vs child.

### API

Standard CRUD endpoints for both Entites.

Added custom middleware for error handling/logging, if an exception is through during the request.

### Tests

NUnit and Moq were used for unit testing. 


