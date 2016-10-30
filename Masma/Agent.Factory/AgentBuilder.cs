using System;
using System.Collections.Generic;
using jade.core;
using jade.core.behaviours;
using jade.wrapper;
using Masma.Common.Setup;
using AgentContainer = jade.wrapper.AgentContainer;

namespace Masma.Builder
{
    public class AgentBuilder
    {
        private readonly AgentContainer _agentContainer;

        private string _agentName;

        private readonly IList<Type> _behaviourTypes;

        private Type _typeOfAgent;

        public AgentBuilder(AgentContainer agentContainer)
        {
            _agentContainer = agentContainer;
            _behaviourTypes = new List<Type>();
        }

        public AgentBuilder Create<T>() where T : Agent
        {
            _typeOfAgent = typeof (T);
            _agentName = typeof (T).Name;

            return this;
        }

        public AgentBuilder Create<T>(string agentName) where T : Agent
        {
            _typeOfAgent = typeof (T);
            _agentName = agentName;

            return this;
        }

        public AgentBuilder WithBehaivour<T>() where T : Behaviour
        {
            _behaviourTypes.Add(typeof (T));

            return this;
        }

        public AgentController Build()
        {
            Agents.Add(_agentName);
            var arguments = new object[_behaviourTypes.Count];
            var idx = 0;

            foreach (var behaviourType in _behaviourTypes)
            {
                arguments[idx++] = behaviourType;
            }

            _behaviourTypes.Clear();
            return _agentContainer.createNewAgent(_agentName, _typeOfAgent.FullName, arguments);
        }
    }
}