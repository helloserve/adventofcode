part1 = (input) =>
    input.split(/[\r\n]+/g).reduce((accumulator, currentLine, lineIndex, array) => {
        if (currentLine.length == 0) {
            return accumulator;
        }
        
        var lineValues = { 
            min : Number.MAX_SAFE_INTEGER, 
            max : Number.MIN_SAFE_INTEGER,
        };

        lineValues = currentLine.split(/\s/).reduce(({ max, min }, currentElement, elementIndex, elementArray) => {
            var element = parseInt(currentElement);
            return {
                min: element < min ? element : min,
                max: element > max ? element : max,
            };
        }, lineValues);

        return accumulator + lineValues.max - lineValues.min;
    }, 0);

part2 = (input) => 
    input.split(/[\r\n]+/g).reduce((accumulator, currentLine, lineIndex, lineArray) => {
        if (currentLine.length === 0) {
            return accumulator;
        }

        return accumulator +
            currentLine.split(/\s/).reduce((outerAccumulator, outerElement, outerIndex, outerArray) => {                
                
                var element_outer = parseInt(outerElement);    
                
                return outerAccumulator + 
                    outerArray.reduce((innerAccumulator, innerElement, innerIndex, innerArray) => {
                        if (outerIndex === innerIndex) {
                            return innerAccumulator;
                        }
        
                        const element_inner = parseInt(innerElement);
                        
                        if (element_inner > element_outer || element_outer % element_inner !== 0) {
                            return innerAccumulator;
                        }
        
                        return innerAccumulator + (element_outer / element_inner);
                    }, 0);
            }, 0);
    }, 0);

module.exports = { part1, part2 };

console.log(part2('5 9 2 8\r\n9 4 7 3\r\n3 8 6 5\r\n'));