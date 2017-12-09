require('./string.js');
var file = require('./file.js');
var path = require('path');

const part1 = (input) => {
    var program = splitInput(input);
    var result = execute(program);
    return max(result.registers, (item) => item.value);
}

const splitInput = (input) => splitOnNewLine(input).reduce((accumulator, currentValue, currentIndex, array) => {
    var parts = currentValue.split('if');
    var part1Match = parts[0].match(/([a-z]+)\s([inc|dec]+)\s([-0-9]+)/);
    var part2Match = parts[1].match(/([a-z]+)\s([=<>!]+)\s([-0-9]+)/);

    return [...accumulator, { 
        register: part1Match[1],
        operation: part1Match[2],
        currentValue: 0,
        operationValue: parseInt(part1Match[3]),
        condition: {
            register: part2Match[1],
            comparer: part2Match[2],
            value: parseInt(part2Match[3])
        }
    }];
}, []);

const execute = (program) => program.reduce((accumulator, currentInstruction, currentIndex, array) => {
    var value = matchCondition(currentInstruction.condition, accumulator.registers) ? op(currentInstruction) : 0;
    var regRecord = accumulator.registers.find((register) => register.name === currentInstruction.register);
    var regRecords = [...accumulator.registers];
    if (regRecord === undefined) {
        regRecord = {
            name: currentInstruction.register,
            value: 0
        };
        regRecords = [...accumulator.registers, regRecord];
    }
    regRecord.value += value;
    var maxValue = Math.max(accumulator.maxValue, regRecord.value);
    return {
        maxValue: maxValue,
        registers: regRecords
    };
}, 
{
    maxValue: Number.MIN_SAFE_INTEGER,
    registers: []
});

const matchCondition = ({ register, comparer, value }, array) => {
    var compareValue = 0;
    var regRecord = array.find((registerElement) => registerElement.name === register);
    if (regRecord !== undefined) {
        compareValue = regRecord.value
    }

    switch (comparer) {
        case "==":
            return compareValue == value;
        case "!=":
            return compareValue != value;
        case "<":
            return compareValue < value;
        case ">":
            return compareValue > value;
        case "<=":
            return compareValue <= value;
        case ">=":
            return compareValue >= value;
    }

    return false;
}

const op = ({ operation, operationValue }) => {
    switch (operation) {
        case "inc":
            return operationValue;
        case "dec":
            return -operationValue;
    }

    return 0;
}

const max = (array, propertyFunc) => array.reduce((accumulator, item, index, array) => propertyFunc(item) > accumulator ? item.value : accumulator, Number.MIN_SAFE_INTEGER)

const part2 = (input) => {
    var program = splitInput(input);
    var result = execute(program);
    return result.maxValue;
}
    
module.exports =  { part1, part2 }

var s = 'b inc 5 if a > 1\r\na inc 1 if b < 5\r\nc dec -10 if a >= 1\r\nc inc -20 if c == 10';
console.log("-->" + part2(s));

file.load(path.resolve(__dirname, './day8.txt'), (data) => {
    var result = part2(data);
    console.log("DAY8 result", result);
});

