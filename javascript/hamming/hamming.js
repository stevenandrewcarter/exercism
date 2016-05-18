function Hamming() {

    this.compute = function (source, compare) {
        if (source.length != compare.length) {
            throw new Error('DNA strands must be of equal length.');
        }
        var difference = 0;
        for (var i = 0; i < source.length; i++) {
            if (source[i] != compare[i])
                difference++;
        }
        return difference;
    }
}

module.exports = Hamming;
