using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SolidityBasic.Contracts.StructsAndArrays.ContractDefinition
{


    public partial class StructsAndArraysDeployment : StructsAndArraysDeploymentBase
    {
        public StructsAndArraysDeployment() : base(BYTECODE) { }
        public StructsAndArraysDeployment(string byteCode) : base(byteCode) { }
    }

    public class StructsAndArraysDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public StructsAndArraysDeploymentBase() : base(BYTECODE) { }
        public StructsAndArraysDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddToArrayFunction : AddToArrayFunctionBase { }

    [Function("addToArray")]
    public class AddToArrayFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint256", "_dna", 2)]
        public virtual BigInteger Dna { get; set; }
    }

    public partial class PeopleFunction : PeopleFunctionBase { }

    [Function("people", typeof(PeopleOutputDTO))]
    public class PeopleFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class PeopleOutputDTO : PeopleOutputDTOBase { }

    [FunctionOutput]
    public class PeopleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "age", 1)]
        public virtual BigInteger Age { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
    }
}
