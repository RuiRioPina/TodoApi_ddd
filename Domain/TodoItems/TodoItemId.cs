using System;
using TodoApi.Domain.Shared;
using Newtonsoft.Json;

namespace TodoApi.Domain.TodoItems
{
    public class TodoItemId : EntityId
    {
        [JsonConstructor]
        public TodoItemId(Guid value) : base(value)
        {
        }

        public TodoItemId(String value) : base(value)
        {
        }

        override
        protected  Object createFromString(String text){
            return new Guid(text);
        }
        
        override
        public String AsString(){
            Guid obj = (Guid) base.ObjValue;
            return obj.ToString();
        }
        public Guid AsGuid(){
            return (Guid) base.ObjValue;
        }
    }
}