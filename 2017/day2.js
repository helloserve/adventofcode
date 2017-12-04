part1 = (input) => {
    var total = 0;
    input.split('\r\n').forEach((line, index) => {            
        var min = Number.MAX_SAFE_INTEGER;
        var max = Number.MIN_SAFE_INTEGER;
        line.split(/\s/).forEach((element, index) => { 
            if (element * 1 < min) {
                min = element * 1;
            }

            if (element * 1 > max) {
                max = element * 1;
            }                
        });

        total += max - min;
    });

    console.log(total);
    return total;
}

part2 = (input) => {
    var total = 0;
    input.split('\r\n').forEach((line, index) => {            
        var elements = line.split(/\s/);

        for (let i = 0; i < elements.length; i++) {
            const element_i = elements[i] * 1;
            
            for (let j = 0; j < elements.length; j++) {
                if (i === j) {
                    continue;
                }

                const element_j = elements[j] * 1;
                
                if (element_j > element_i || element_i % element_j !== 0) {
                    continue;
                }

                total += element_i / element_j;
            }
        }

    });

    console.log(total);
    return total;        
}

module.exports = { part1, part2 };