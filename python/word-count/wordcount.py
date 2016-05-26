import re


def word_count(sentence):
    words = re.split("(?u)\W+|_", sentence.decode("utf-8").lower())
    words = filter(None, words)
    count = {}
    for word in words:
        count[word] = 1 if word not in count else count[word] + 1
    return count
