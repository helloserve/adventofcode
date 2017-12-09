var chai = require('chai');
var expect = chai.expect;
var day9 = require('../day9.js');
var file = require('../file.js');
var path = require('path');

describe('Day 9 garbage', () => {
    it('<>', () => {
        var result = day9.garbage('<>', 0)
        expect(result.index).to.equals(('<>').length);
        expect(result.count).to.equals(0);
    });
    it('<random characters>', () => {
        var result = day9.garbage('<random characters>', 0);
        expect(result.index).to.equals(('<random characters>').length);
        expect(result.count).to.equals(17);
    });
    it('<<<<>', () => {
        var result = day9.garbage('<<<<>', 0);
        expect(result.index).to.equals(('<<<<>').length);
        expect(result.count).to.equals(3);
    });
    it('<{!>}>', () => {
        var result = day9.garbage('<{!>}>', 0);
        expect(result.index).to.equals(('<{!>}>').length);
        expect(result.count).to.equals(2);
    });
    it('<!!>', () => {
        var result = day9.garbage('<!!>', 0);
        expect(result.index).to.equals(('<!!>').length);
        expect(result.count).to.equals(0);
    });
    it('<!!!>>', () => {
        var result = day9.garbage('<!!!>>', 0);
        expect(result.index).to.equals(('<!!!>>').length);
        expect(result.count).to.equals(0);
    });
    it('<{o"i!a,<{i<a>', () => {
        var result = day9.garbage('<{o"i!a,<{i<a>', 0);
        expect(result.index).to.equals(('<{o"i!a,<{i<a>').length);
        expect(result.count).to.equals(10);
    });
});

describe('Day 9 group', () => {
    it('{}', () => {
        var result = day9.group('{}', 0, 1);
        expect(result.count).to.equals(1);
        expect(result.score).to.equals(1);
    });
    it('{{{}}}', () => {
        var result = day9.group('{{{}}}', 0, 1);
        expect(result.count).to.equals(3);
        expect(result.score).to.equals(6);
    });
    it('{{},{}}', () => {
        var result = day9.group('{{},{}}', 0, 1);
        expect(result.count).to.equals(3);
        expect(result.score).to.equals(5);
    });
    it('{{{},{},{{}}}}', () => {
        var result = day9.group('{{{},{},{{}}}}', 0, 1);
        expect(result.count).to.equals(6);
        expect(result.score).to.equals(16);
    });
    it('{<{},{},{{}}>}', () => {
        var result = day9.group('{<{},{},{{}}>}', 0, 1);
        expect(result.count).to.equals(1);
    });
    it('{<a>,<a>,<a>,<a>}', () => {
        var result = day9.group('{<a>,<a>,<a>,<a>}', 0, 1);
        expect(result.count).to.equals(1);
        expect(result.score).to.equals(1);
    });
    it('{{<a>},{<a>},{<a>},{<a>}}', () => {
        var result = day9.group('{{<a>},{<a>},{<a>},{<a>}}', 0, 1);
        expect(result.count).to.equals(5);
        expect(result.score).to.equals(9);
    });
    it('{{<!>},{<!>},{<!>},{<a>}}', () => {
        var result = day9.group('{{<!>},{<!>},{<!>},{<a>}}', 0, 1);
        expect(result.count).to.equals(2);
        expect(result.score).to.equals(3);
    });
})

describe('Day 9', () => {

    it('Part 1', function(done) { 
        file.load(path.resolve(__dirname, '../day9.txt'), (data) => {
            var result = day9.part1(data);
            console.log("day9 result", result);
            expect(result).to.equals(10800).satisfy(done());
        });
    });

    it('Part 2', function(done) { 
        file.load(path.resolve(__dirname, '../day9.txt'), (data) => {
            var result = day9.part2(data);
            console.log("day9 result", result);
            expect(result).to.equals(4522).satisfy(done());
        });
    });
});