// -----------------------------------------------------------------------
// <copyright company="Web Illumination Ltd." file="CalculatorRepository.cs">
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
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Xml;
    #endregion

    /// <summary>
    /// Calculator repository.
    /// </summary>
    public class CalculatorRepository
    {
        /// <summary>
        /// The <see cref="ICalculatorChannel"/> proxy.
        /// </summary>
        private readonly ICalculatorChannel proxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdamStacey.DemoCalculator.CalculatorRepository"/> class.
        /// </summary>
        /// <param name="endpointAddress">Endpoint address.</param>
        /// <param name="timeout">The timeout.</param>
        public CalculatorRepository(string endpointAddress, double timeout)
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(timeout),
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                AllowCookies = true,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max
            };

            binding.Security.Mode = BasicHttpSecurityMode.None;

            EndpointAddress address = new EndpointAddress(endpointAddress);

            ChannelFactory<ICalculatorChannel> factory = new ChannelFactory<ICalculatorChannel>(binding, address);

            this.proxy = factory.CreateChannel();
        }

        /// <summary>
        /// Adds asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> AddAsync(int intA, int intB)
        {
            return await this.proxy.AddAsync(intA, intB);
        }

        /// <summary>
        /// Subtracts asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> SubtractAsync(int intA, int intB)
        {
            return await this.proxy.SubtractAsync(intA, intB);
        }

        /// <summary>
        /// Multiplies asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> MultiplyAsync(int intA, int intB)
        {
            return await this.proxy.MultiplyAsync(intA, intB);
        }

        /// <summary>
        /// Divides asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> DivideAsync(int intA, int intB)
        {
            return await this.proxy.DivideAsync(intA, intB);
        }
    }
}