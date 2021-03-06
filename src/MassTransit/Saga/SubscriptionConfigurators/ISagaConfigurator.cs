﻿// Copyright 2007-2015 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.Saga.SubscriptionConfigurators
{
    using System;
    using ConsumeConfigurators;


    public interface ISagaConfigurator<TSaga> :
        IPipeConfigurator<SagaConsumeContext<TSaga>>,
        IConsumeConfigurator
        where TSaga : class, ISaga
    {
        /// <summary>
        /// Configure a message type for the consumer, such as adding middleware to the pipeline for
        /// the message type.
        /// </summary>
        /// <typeparam name="T">The message type</typeparam>
        /// <param name="configure">The callback to configure the message pipeline</param>
        void ConfigureMessage<T>(Action<ISagaMessageConfigurator<T>> configure)
            where T : class;
    }
}