﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using AwsSignatureVersion4.Integration.ApiGateway.Authentication;
using Shouldly;
using Xunit;

namespace AwsSignatureVersion4.Integration.S3
{
    public class PostAsyncShould : S3IntegrationBase
    {
        public PostAsyncShould(IntegrationTestContext context)
            : base(context)
        {
        }

        [Theory]
        [InlineData(IamAuthenticationType.User)]
        [InlineData(IamAuthenticationType.Role)]
        public async Task ThrowNotSupportedException(IamAuthenticationType iamAuthenticationType)
        {
            // Arrange
            var bucketObject = new BucketObject(BucketObjectKey.WithoutPrefix);

            // Act
            var actual = HttpClient.PostAsync(
                $"{Context.S3BucketUrl}/{bucketObject.Key}",
                bucketObject.StringContent,
                Context.RegionName,
                Context.ServiceName,
                ResolveMutableCredentials(iamAuthenticationType));

            // Assert
            await actual.ShouldThrowAsync<NotSupportedException>();
        }
    }
}
