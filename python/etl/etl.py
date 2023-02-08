def transform(legacy_data):
    return {letter.lower(): val for val in legacy_data for letter in legacy_data[val]}
