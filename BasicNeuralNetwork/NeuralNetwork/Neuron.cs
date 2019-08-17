using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicNeuralNetwork.NeuralNetwork
{
    enum NeuronType
    {
        hidden, input, output
    }

    class Neuron
    {
        public NeuronType type;
        private float bias;
        List<Connection> outputs;

        private float value; // Biased value

        public Neuron(float bias, NeuronType neuronType)
        {
            type = neuronType;
            outputs = new List<Connection>();
        }

        public void AddConnection(Neuron connetc_to)
        {
            Connection newConnection = new Connection(connetc_to);
        }

        public void RecieveValue(float value)
        {
            this.value = value * bias;

            if(type != NeuronType.output)
            {
                foreach(var connection in outputs)
                {
                    connection.Send(value);
                }
            }
        }

        public float GetValue()
        {
            return value;
        }
    }

    class Connection
    {
        float weight;
        Neuron target;

        public Connection(Neuron to)
        {
            target = to;
        }

        public void Send(float value)
        {
            target.RecieveValue(value * weight);
        }
    }
}
