function convert(ocrNumber) {
  if (ocrNumber == " _ | ||_|   ")
    return "0";
  else if (ocrNumber == "     |  |   ")
    return "1";
  else if (ocrNumber == " _  _||_    ")
    return "2";
  else if (ocrNumber == " _  _| _|   ")
    return "3";
  else if (ocrNumber == "   |_|  |   ")
    return "4";
  else if (ocrNumber == " _ |_  _|   ")
    return "5";
  else if (ocrNumber == " _ |_ |_|   ")
    return "6";
  else if (ocrNumber == " _   |  |   ")
    return "7";
  else if (ocrNumber == " _ |_||_|   ")
    return "8";
  else if (ocrNumber == " _ |_| _|   ")
    return "9";
  return "?";
}

module.exports = {
  convert: function (ocrNumber) {
    var rows = ocrNumber.split('\n');
    var numberOfRows = rows.length / 4;
    var results = [];
    for (var r = 0; r < numberOfRows; r++) {
      var row = "";
      if (rows.length % 4 != 0 || rows[4 * r].length % 3 != 0) {
        return "?";
      }
      var digits = rows[4 * r].length / 3;
      for (var i = 0; i < digits; i++) {
        var block = "";
        for (var y = 0; y < 4; y++) {
          for (var x = 0; x < 3; x++) {
            block += rows[(r * 4) + y][(i * 3) + x];
          }
        }
        row += convert(block);
      }
      results.push(row);
    }
    return results.join(',');
  }
};
