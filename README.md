# LexisNexis Technical Assessment

## Description

This system manages product inventory with CRUD functionality, as well as manage product categories.

## Table of Contents
*   [Prerequisites](#prerequisites)
*   [Build Instructions](#build-instructions)
*   [Unit Test Instructions](#test-instructions)
*   [Run Instructions (Locally)](#run-instructions-locally)

## Prerequisites

*   Have the latest .net LTS installed (ver 10)

## Build Instructions

Once you have cloned repo, solution should build successfully within IDE of choice.

## Unit Test Instructions

There are 2 sets of  unit test, infrastructure tests and application tests.

All tests should be passing.

To run the unit tests, just use standard visual studio unit test window.

## Run Instructions (Locally)

If build is successful, you may run the api on your local machine.

You  may use any rest client of your choice. (Postman, RClient etc)

The api can be accessed at https://localhost:7044 OR http://localhost:5180

### Endpoints:

GET /api/products (with pagination, filtering by category, and search by name)

GET /api/products/{id}

POST /api/products

PUT /api/products/{id}

DELETE /api/products/{id}

GET /api/categories (returns flat list)

GET /api/categories/tree (returns hierarchical tree structure)

POST /api/categories

### Payload structure:

Category:
```bash
  {
      "Id" : "00000000-0000-0000-0000-000000000000",
      "name": "asd",
      "description": "asdf",
      "parentCategoryId": null
  }
```
Product:
```bash
  {
    {
        "id": "00000000-0000-0000-0000-000000000000",
        "name": null,
        "description": null,
        "categoryId": "00000000-0000-0000-0000-000000000000",
        "unitPrice": 0.0,
        "sku": null,
        "createdAt": "0001-01-01T00:00:00",
        "updatedAt": "0001-01-01T00:00:00"
    }
  }
```
