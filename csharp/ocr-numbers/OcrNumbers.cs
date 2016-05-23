class OcrNumbers
{
  private static string ConvertDigit(string ocrNumber)
  {
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

  public static string Convert(string ocrNumber)
  {
    var rows = ocrNumber.Split('\n');
    if (rows.Length % 4 != 0 || rows[0].Length % 3 != 0)
    {
      return "?";
    }    
    var digits = rows[0].Length / 3;
    var results = "";
    for (var i = 0; i < digits; i++)
    {
      var block = "";
      for (var y = 0; y < 4; y++)
      {
        for (var x = 0; x < 3; x++)
        {
          block += rows[y][(i * 3) + x];
        }
      }
      results += ConvertDigit(block);
    }
    return results;
  }
}
