// -----------------------------------------------------------------------
// <copyright company="Web Illumination Ltd." file="CalculatorClient.cs">
//     Web Illumination Ltd. All rights reserved.
// </copyright>
// <author>
//      Adam Stacey, Solution Architect
//      me@adamstacey.co.uk
// </author>
// -----------------------------------------------------------------------
namespace AdamStacey.DemoCalculator
{
    #region Usings
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Calculator client.
    /// </summary>
    public class CalculatorClient : ClientBase<ICalculatorService>, ICalculatorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdamStacey.DemoCalculator.CalculatorClient"/> class.
        /// </summary>
        public CalculatorClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdamStacey.DemoCalculator.CalculatorClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Endpoint configuration name.</param>
        public CalculatorClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdamStacey.DemoCalculator.CalculatorClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Endpoint configuration name.</param>
        /// <param name="remoteAddress">Remote address.</param>
        public CalculatorClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdamStacey.DemoCalculator.CalculatorClient"/> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Endpoint configuration name.</param>
        /// <param name="remoteAddress">Remote address.</param>
        public CalculatorClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdamStacey.DemoCalculator.CalculatorClient"/> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="endpoint">The endpoint.</param>
        public CalculatorClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint)
        {
        }

        /// <summary>
        /// Adds asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> AddAsync(int intA, int intB)
        {
            return await Channel.AddAsync(intA, intB);
        }

        /// <summary>
        /// Subtracts asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> SubtractAsync(int intA, int intB)
        {
            return await Channel.SubtractAsync(intA, intB);
        }

        /// <summary>
        /// Multiplies asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> MultiplyAsync(int intA, int intB)
        {
            return await Channel.MultiplyAsync(intA, intB);
        }

        /// <summary>
        /// Divides asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> DivideAsync(int intA, int intB)
        {
            return await Channel.DivideAsync(intA, intB);
        }
    }
}