def transform(legacy_data):
    scores = {}
    for val, letters in legacy_data.items():
        for letter in letters:
            scores[letter.lower()] = val
    return scores
