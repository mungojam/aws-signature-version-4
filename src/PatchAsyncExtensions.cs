using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using AwsSignatureVersion4.Private;

// ReSharper disable once CheckNamespace
namespace System.Net.Http
{
    /// <summary>
    /// Extensions to <see cref="HttpClient"/> extending it to support PATCH requests signed with
    /// AWS Signature Version 4.
    /// </summary>
    public static class PatchAsyncExtensions
    {
        /// <summary>
        /// .NET Standard 2.0 does not support HttpMethod.Patch, thus we create the method here
        /// instead.
        /// </summary>
        internal static readonly HttpMethod PatchMethod = new("PATCH");

        #region PatchAsync(string, HttpContent, string, string, <credentials>)

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request to the specified Uri as an asynchronous
        /// operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            string requestUri,
            HttpContent content,
            string regionName,
            string serviceName,
            AWSCredentials credentials) =>
            self.PatchAsync(
                requestUri,
                content,
                CancellationToken.None,
                regionName,
                serviceName,
                credentials);

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request to the specified Uri as an asynchronous
        /// operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            string requestUri,
            HttpContent content,
            string regionName,
            string serviceName,
            ImmutableCredentials credentials) =>
            self.PatchAsync(
                requestUri,
                content,
                CancellationToken.None,
                regionName,
                serviceName,
                credentials);

        #endregion

        #region PatchAsync(Uri, HttpContent, string, string, <credentials>)

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request to the specified Uri as an asynchronous
        /// operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            Uri requestUri,
            HttpContent content,
            string regionName,
            string serviceName,
            AWSCredentials credentials) =>
            self.PatchAsync(
                requestUri,
                content,
                CancellationToken.None,
                regionName,
                serviceName,
                credentials);

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request to the specified Uri as an asynchronous
        /// operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            Uri requestUri,
            HttpContent content,
            string regionName,
            string serviceName,
            ImmutableCredentials credentials) =>
            self.PatchAsync(
                requestUri,
                content,
                CancellationToken.None,
                regionName,
                serviceName,
                credentials);

        #endregion

        #region PatchAsync(string, HttpContent, CancellationToken, string, string, <credentials>)

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request with a cancellation token as an
        /// asynchronous operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of
        /// cancellation.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken,
            string regionName,
            string serviceName,
            AWSCredentials credentials) =>
            self.PatchAsync(
                requestUri.ToUri(),
                content,
                cancellationToken,
                regionName,
                serviceName,
                credentials);

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request with a cancellation token as an
        /// asynchronous operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of
        /// cancellation.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken,
            string regionName,
            string serviceName,
            ImmutableCredentials credentials) =>
            self.PatchAsync(
                requestUri.ToUri(),
                content,
                cancellationToken,
                regionName,
                serviceName,
                credentials);

        #endregion

        #region PatchAsync(Uri, HttpContent, CancellationToken, string, string, <credentials>)

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request with a cancellation token as an
        /// asynchronous operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of
        /// cancellation.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static async Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            Uri requestUri,
            HttpContent content,
            CancellationToken cancellationToken,
            string regionName,
            string serviceName,
            AWSCredentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));

            var immutableCredentials = await credentials.GetCredentialsAsync();

            var response = await self.PatchAsync(
                requestUri,
                content,
                cancellationToken,
                regionName,
                serviceName,
                immutableCredentials);

            return response;
        }

        /// <summary>
        /// Send a Signature Version 4 signed PATCH request with a cancellation token as an
        /// asynchronous operation.
        /// </summary>
        /// <param name="self">
        /// The extension target.
        /// </param>
        /// <param name="requestUri">
        /// The Uri the request is sent to.
        /// </param>
        /// <param name="content">
        /// The HTTP request content sent to the server.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of
        /// cancellation.
        /// </param>
        /// <param name="regionName">
        /// The system name of the AWS region associated with the endpoint, e.g. "us-east-1".
        /// </param>
        /// <param name="serviceName">
        /// The signing name of the service, e.g. "execute-api".
        /// </param>
        /// <param name="credentials">
        /// AWS credentials containing the following parameters:
        /// - The AWS public key for the account making the service call.
        /// - The AWS secret key for the account making the call, in clear text.
        /// - The session token obtained from STS if request is authenticated using temporary
        ///   security credentials, e.g. a role.
        /// </param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="requestUri"/> is null.
        /// </exception>
        /// <exception cref="HttpRequestException">
        /// The request failed due to an underlying issue such as network connectivity, DNS
        /// failure, server certificate validation or timeout.
        /// </exception>
        /// <remarks>
        /// This operation will not block. The returned <see cref="Task{TResult}"/> object will
        /// complete once the entire response including content is read.
        /// </remarks>
        public static Task<HttpResponseMessage> PatchAsync(
            this HttpClient self,
            Uri requestUri,
            HttpContent content,
            CancellationToken cancellationToken,
            string regionName,
            string serviceName,
            ImmutableCredentials credentials)
        {
            var request = new HttpRequestMessage(PatchMethod, requestUri)
            {
                Content = content
            };

            return self.SendAsync(
                request,
                cancellationToken,
                regionName,
                serviceName,
                credentials);
        }

        #endregion
    }
}
