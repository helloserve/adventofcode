var chai = require('chai');
var expect = chai.expect;
var day5 = require('../day5.js');
var file = require('../file.js');
var path = require('path');

describe('Day 5', () => {

    it('Part 1 [0 3 0 1 -3]', () => {
        var result = day5.part1('0\r\n3\r\n0\r\n1\r\n-3');
        expect(result).to.equal(5);
    });

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day5.txt'), (data) => {
            var result = day5.part1(data);
            console.log("DAY5 result", result);
            expect(result).to.equals(375042).satisfy(done());
        });
    });

    it('Part 2 [0 3 0 1 -3]', () => {
        var result = day5.part2('0\r\n3\r\n0\r\n1\r\n-3');
        expect(result).to.equal(10);
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day5.txt'), (data) => {
            var result = day5.part2(data);
            console.log("DAY5 result", result);
            expect(result).to.equals(28707598).satisfy(done());
        });
    });
});