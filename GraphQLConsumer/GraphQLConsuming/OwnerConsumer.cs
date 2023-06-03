using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQLConsumer.Models;
using System;

namespace GraphQLConsumer.GraphQLConsuming
{
    public class OwnerConsumer
    {
        private readonly IGraphQLClient _client;

        public OwnerConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Owner>> GetAllOwners()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                          query ownersQuery {
                            owners {
                              id
                              name
                              address
                              accounts {
                                id
                                type
                                description
                              }
                            }
                          }"
            };

            var response = await _client.SendQueryAsync<ResponseOwnerCollectionType>(query);
            return response.Data.Owners;
        }

        public async Task<Owner> GetOwnerById(Guid ownerId)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                          query ownerQuery($ownerID: ID!) {
                            owner(ownerId: $ownerID) {
                              id
                              name
                              address
                              accounts {
                                id
                                type
                                description
                              }
                            }
                          }",
                Variables = new { ownerID =  ownerId }
            };

            var response = await _client.SendQueryAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }

        public async Task<Owner> CreateOwner(OwnerInput ownerToCreate)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                          mutation ($owner: ownerInput!) {
                            createOwner(owner: $owner) {
                              id
                              name
                              address
                            }
                          }",
                Variables = new { owner = ownerToCreate }
            };

            var response = await _client.SendMutationAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }

        public async Task<Owner> UpdateOwner(Guid ownerId, OwnerInput ownerToCreate)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                          mutation ($owner: ownerInput!, $ownerId: ID!) {
                            updateOwner(owner: $owner, ownerId: $ownerId) {
                              id
                              name
                              address
                            }
                          }",
                Variables = new { owner = ownerToCreate, ownerId = ownerId }
            };

            var response = await _client.SendMutationAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }

        public async Task<string> DeleteOwner(Guid ownerId)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                          mutation ($ownerId: ID!) {
                            deleteOwner(ownerId: $ownerId)
                          }",
                Variables = new { ownerId = ownerId }
            };

            var response = await _client.SendMutationAsync<string>(query);
            return response.Data;
        }
    }
}
