part1 = (input) =>
    input.split(/[\r\n]+/g).reduce((accumulator, currentLine, lineIndex, array) => {
        if (currentLine.length == 0) {
            return accumulator;
        }
        
        var lineValues = { 
            min : Number.MAX_SAFE_INTEGER, 
            max : Number.MIN_SAFE_INTEGER 
        };

        lineValues = currentLine.split(/\s/).reduce((values, currentElement, elementIndex, elementArray) => {
            var element = parseInt(currentElement);            
            if (element < values.min) {
                values.min = element;
            }
            if (element > values.max) {
                values.max = element;
            }                
            return values;
        }, lineValues);

        return accumulator + lineValues.max - lineValues.min;
    }, 0);

part2 = (input) => 
    input.split(/[\r\n]+/g).reduce((accumulator, currentLine, lineIndex, lineArray) => {
        if (currentLine.length === 0) {
            return accumulator;
        }

        return accumulator + 
            currentLine.split(/\s/).reduce((value, currentElement, elementIndex, elementArray) => {                
                for (let i = 0; i < elementArray.length; i++) {
                    const element_i = elementArray[i] * 1;
                    
                    for (let j = 0; j < elementArray.length; j++) {
                        if (i === j) {
                            continue;
                        }
        
                        const element_j = elementArray[j] * 1;
                        
                        if (element_j > element_i || element_i % element_j !== 0) {
                            continue;
                        }
        
                        return element_i / element_j;
                    }
                }

                return 0;
            }, 0);
    }, 0);

module.exports = { part1, part2 };

console.log(part1('5 1 9 5\r\n7 5 3\r\n2 4 6 8\r\n'));