# TeamLunchAPI

I used <a href="https://www.getpostman.com/" target="_blank">Postman</a> to interact with the API. Included in the repo is my collection of Postman commands (TeamLunch Tests.postman_collection.json) that can be imported to quickly get started with the API!

## Assumptions
- Constraints on optimal meal order:
  - Everyone must have a meal they can eat
  - A meal from a higher rated restaurant is better than one from a lower rated restaurant
- Cost of meals does not matter
- No logistical issues when getting meals

## Notes
- The data in this API is modeled to be progressively/iteratively built over a long period of time
- No support for authorization or authentication

## Bugs
- My unit tests currently cannot reference my API. Apparently NETFramework 4.6.1 projects (unit tests) cannot target projects using NETCore 1.1 (API).
