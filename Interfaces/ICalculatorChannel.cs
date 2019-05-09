// -----------------------------------------------------------------------
// <copyright company="Web Illumination Ltd." file="ICalculatorChannel.cs">
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
    #endregion

    /// <summary>
    /// Calculator channel.
    /// </summary>
    public interface ICalculatorChannel : ICalculatorService, IClientChannel
    {
    }
}