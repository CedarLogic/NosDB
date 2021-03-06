﻿// /*
// * Copyright (c) 2016, Alachisoft. All Rights Reserved.
// *
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// *
// * http://www.apache.org/licenses/LICENSE-2.0
// *
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alachisoft.NosDB.Common.Communication
{
    public class ChannelResponse:IResponse,Common.Serialization.ICompactSerializable
    {
        public long RequestId { get; set; }

        public IChannel Channel{ get; set; }

        public Net.Address Source{get;set;}

        public Exception Error { get; set; }

        public object ResponseMessage { get; set; }

        public void Deserialize(Serialization.IO.CompactReader reader)
        {
            this.RequestId = reader.ReadInt64();
            this.Source = (Alachisoft.NosDB.Common.Net.Address)reader.ReadObject();
            this.ResponseMessage = reader.ReadObject();
            this.Error = reader.ReadObject() as Exception;
        }

        public void Serialize(Serialization.IO.CompactWriter writer)
        {
            writer.Write(RequestId);
            writer.WriteObject(Source);
            writer.WriteObject(ResponseMessage);
            writer.WriteObject(this.Error);
        }
    }
}
