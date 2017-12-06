var chai = require('chai');
var expect = chai.expect;
var day6 = require('../day6.js');
var file = require('../file.js');
var path = require('path');

describe('Day 6', () => {

    it('Part 1 [0 2 7 0]', () => {
        var result = day6.part1('0 2 7 0');
        expect(result).to.equal(5);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day6.txt'), (data) => {
            var result = day6.part1(data);
            console.log("DAY6 result", result);
            expect(result).to.equals(6681).satisfy(done());
        });
    });

    it('Part 2 [2 4 1 2]', () => {
        var result = day6.part2('2 4 1 2');
        expect(result).to.equal(4);
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day6.txt'), (data) => {
            var result = day6.part2(data);
            console.log("DAY6 result", result);
            expect(result).to.equals(2392).satisfy(done());
        });
    });
});