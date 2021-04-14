using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SolidityBasic.Contracts.StructsAndArrays.ContractDefinition;

namespace SolidityBasic.Contracts.StructsAndArrays
{
    public partial class StructsAndArraysService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, StructsAndArraysDeployment structsAndArraysDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<StructsAndArraysDeployment>().SendRequestAndWaitForReceiptAsync(structsAndArraysDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, StructsAndArraysDeployment structsAndArraysDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<StructsAndArraysDeployment>().SendRequestAsync(structsAndArraysDeployment);
        }

        public static async Task<StructsAndArraysService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, StructsAndArraysDeployment structsAndArraysDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, structsAndArraysDeployment, cancellationTokenSource);
            return new StructsAndArraysService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public StructsAndArraysService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddToArrayRequestAsync(AddToArrayFunction addToArrayFunction)
        {
             return ContractHandler.SendRequestAsync(addToArrayFunction);
        }

        public Task<TransactionReceipt> AddToArrayRequestAndWaitForReceiptAsync(AddToArrayFunction addToArrayFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addToArrayFunction, cancellationToken);
        }

        public Task<string> AddToArrayRequestAsync(string name, BigInteger dna)
        {
            var addToArrayFunction = new AddToArrayFunction();
                addToArrayFunction.Name = name;
                addToArrayFunction.Dna = dna;
            
             return ContractHandler.SendRequestAsync(addToArrayFunction);
        }

        public Task<TransactionReceipt> AddToArrayRequestAndWaitForReceiptAsync(string name, BigInteger dna, CancellationTokenSource cancellationToken = null)
        {
            var addToArrayFunction = new AddToArrayFunction();
                addToArrayFunction.Name = name;
                addToArrayFunction.Dna = dna;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addToArrayFunction, cancellationToken);
        }

        public Task<PeopleOutputDTO> PeopleQueryAsync(PeopleFunction peopleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PeopleFunction, PeopleOutputDTO>(peopleFunction, blockParameter);
        }

        public Task<PeopleOutputDTO> PeopleQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var peopleFunction = new PeopleFunction();
                peopleFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PeopleFunction, PeopleOutputDTO>(peopleFunction, blockParameter);
        }
    }
}
