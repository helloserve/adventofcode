var chai = require('chai');
var expect = chai.expect;
var day2 = require('../day2.js');
var file = require('../file.js');
var path = require('path');

describe('Day 2', () => {

    it('Part 1 ex', () => {
        var result = day2.part1('5 1 9 5\r\n7 5 3\r\n2 4 6 8\r\n');
        expect(result).to.equal(18);
    });

    it('Part 1', (done) => { 
        file.load(path.resolve(__dirname, '../day2.txt'), (data) => {
            var result = day2.part1(data);
            console.log("DAY2 result", result);
            expect(result).to.equals(41919).satisfy(done());
        });
    });

    it('Part 2 ex', () => {
        var result = day2.part2('5 9 2 8\r\n9 4 7 3\r\n3 8 6 5\r\n');
        expect(result).to.equal(9);
    });

    it('Part 2', (done) => { 
        file.load(path.resolve(__dirname, '../day2.txt'), (data) => {
            var result = day2.part2(data);
            console.log("DAY2 result", result);
            expect(result).to.equals(303).satisfy(done());
        });
    });
});