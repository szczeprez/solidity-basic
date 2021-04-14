pragma solidity >=0.5.0 <0.8.5;

contract ZombieFactory {

    // This will be stored permanently in the blockchain
    uint dnaDigits = 16;

	// Addition: x + y
	// Subtraction: x - y,
	// Multiplication: x * y
	// Division: x / y
	// Modulus / remainder: x % y (for example, 13 % 5 is 3, because if you divide 5 into 13, 3 is the remainder)
	// Exponential operator (i.e. "x to the power of y", x^y)
    uint dnaModulus = 10 ** dnaDigits; 
	
	struct Zombie {
		string name; 
		uint dna; 
	}
	
	// Array with a fixed length of 2 elements:
	uint[2] fixedArray;
	// another fixed Array, can contain 5 strings:
	string[5] stringArray;
	// a dynamic Array - has no fixed size, can keep growing:
	uint[] dynamicArray;

	// Public array
	Zombie[] public zombies; 
	
	function _createDeadZombie(string memory _name, uint _dna) private {
		zombies.push(Zombie(_name, _dna)); 
	{
	
	function _generateRandomDna(string memory _str) private view returns (uint) {
        uint rand = uint(keccak256(abi.encodePacked(_str)));
        return rand % dnaModulus;
	}
}
