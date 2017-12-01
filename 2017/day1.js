var File = require('./file.js');

function Day1() {

    this.part1File = function(filepath, callback) {
        var file = new File();
        return file.load(filepath, (data) => {
            return callback(this.part1(data));
        });
    }

    this.part1 = function(input) {
        var i = 0;
        var sum = 0;
        while (i < input.length - 1) {
            if (input[i] === input[i + 1]) {
                sum += (input[i] * 1);
            }
            i++;
        }
        if (input[i] === input[0]) {
            sum += (input[i] * 1);
        }

        console.log(sum);
        return sum;
    }

    this.part2File = function(filepath, callback) {
        var file = new File();
        return file.load(filepath, (data) => {
            return callback(this.part2(data));
        });
    }

    this.part2 = function(input) {
        var i = 0;
        var sum = 0;
        var offset = input.length / 2;
        //console.log('offset=' + offset);
        while (i < input.length) {
            var j = offset + i;
            //console.log('i=' + i + ' j=' + j);
            if (j >= input.length) {
                j = j - input.length;
            }

            if (input[i] === input[j]) {
                sum += (input[i] * 1);
            }
            i++;
        }

        console.log(sum);
        return sum;
    }
}
    
module.exports = Day1;