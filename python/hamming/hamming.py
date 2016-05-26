def distance(source, destination):
    difference = 0
    for i, c in enumerate(source):
        if destination[i] != c:
            difference += 1
    return difference
