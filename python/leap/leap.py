"""Module with leap year functions"""

def leap_year(year):
    """Determine if year is a leap year

    param year: int - the year to test
    """

    if year % 4 > 0:
        return False
    if year % 100 == 0 and year % 400 != 0:
        return False
    return True

