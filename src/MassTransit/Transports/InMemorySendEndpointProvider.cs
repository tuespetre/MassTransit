// Copyright 2007-2015 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Transports
{
    using System;
    using System.Threading.Tasks;
    using Serialization;


    public class InMemorySendEndpointProvider :
        ISendEndpointProvider
    {
        readonly IMessageSerializer _defaultSerializer;
        readonly Uri _sourceAddress;
        readonly ISendTransportProvider _transportProvider;

        public InMemorySendEndpointProvider(Uri sourceAddress, ISendTransportProvider transportProvider,
            IMessageSerializer defaultSerializer)
        {
            _transportProvider = transportProvider;
            _defaultSerializer = defaultSerializer;
            _sourceAddress = sourceAddress;
        }

        public async Task<ISendEndpoint> GetSendEndpoint(Uri address)
        {
            ISendTransport sendTransport = _transportProvider.GetSendTransport(address);

            return new SendEndpoint(sendTransport, _defaultSerializer, address, _sourceAddress);
        }
    }
}