"""Functions used in preparing Guido's gorgeous lasagna.

Learn about Guido, the creator of the Python language: https://en.wikipedia.org/wiki/Guido_van_Rossum
"""

EXPECTED_BAKE_TIME = 40
PREPARATION_TIME = 2

def bake_time_remaining(elapsed_bake_time):
    """Calculate the bake time remaining.

    :param elapsed_bake_time: int - baking time already elapsed.
    :return: int - remaining bake time (in minutes) derived from 'EXPECTED_BAKE_TIME'.

    Function that takes the actual minutes the lasagna has been in the oven as
    an argument and returns how many minutes the lasagna still needs to bake
    based on the `EXPECTED_BAKE_TIME`.
    """
    return EXPECTED_BAKE_TIME - elapsed_bake_time

def preparation_time_in_minutes(layers):
    """Calculate the preperation time

    :param layers: int - the number of layers to prepare
    :return: int - time (in minutes) to prepare the lasagna

    Function that the number of layers and returns how many minutes to prepare
    based on the 'PREPARATION_TIME'.
    """
    return layers * PREPARATION_TIME

def elapsed_time_in_minutes(layers, time):
    """Calculate the time elapsed.

    :param layers: int - the number of layers in hte lasagna.
    :param time: int
    :return: int - time (in minutes) that has elapsed.

    Function that calculates the total time that has elapsed in the preperation of
    the lasagna.
    """
    elapsed = preparation_time_in_minutes(layers) + time
    return elapsed
