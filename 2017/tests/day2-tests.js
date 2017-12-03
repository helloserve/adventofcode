var chai = require('chai');
var expect = chai.expect;
var Day2 = require('../day2.js');
var path = require('path');

describe('Day 2', () => {

    it('Part 1 ex', () => {
        var day2 = new Day2();
        var result = day2.part1('5 1 9 5\r\n7 5 3\r\n2 4 6 8\r\n');
        expect(result).to.equal(18);
    });

    it('Part 1', () => { 
        new Day2().part1File(path.resolve(__dirname, '../day2.txt'), (data) => {
            console.log("DAY2 result", data);
            expect(data).to.equals(41919);
        });
    });

    it('Part 2 ex', () => {
        var day2 = new Day2();
        var result = day2.part2('5 9 2 8\r\n9 4 7 3\r\n3 8 6 5\r\n');
        expect(result).to.equal(9);
    });

    it('Part 2', () => { 
        new Day2().part2File(path.resolve(__dirname, '../day2.txt'), (data) => {
            console.log("DAY2 result", data);
            expect(data).to.equals(303);
        });
    });
});