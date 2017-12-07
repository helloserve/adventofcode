var chai = require('chai');
var expect = chai.expect;
var day7 = require('../day7.js');
var file = require('../file.js');
var path = require('path');

describe('Day 7', () => {

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day7.txt'), (data) => {
            var result = day7.part1(data);
            console.log("DAY7 result", result);
            expect(result).to.equals('aapssr').satisfy(done());
        });
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day7.txt'), (data) => {
            var result = day7.part2(data);
            console.log("DAY7 result", result);
            expect(result).to.equals(1458).satisfy(done());
        });
    });
});