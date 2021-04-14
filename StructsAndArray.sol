pragma solidity 0.8.3; 

contract StructsAndArrays {

    struct Person {
    uint age;
    string name;
    }

    Person[] public people;

    // create a New Person:
    Person satoshi = Person(172, "Satoshi");

    // Functions are public by default
    function addToArray (string memory _name, uint _dna) public {
        // Add that person to the Array:
        people.push(satoshi);
        people.push(Person(16, "Vitalik"));

        uint[] numbers;
        numbers.push(5);
        numbers.push(10);
        numbers.push(15);
        // numbers is now equal to [5, 10, 15]
    }
}