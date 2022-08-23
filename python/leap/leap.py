"""Module with leap year functions"""

def leap_year(year):
    """Determine if year is a leap year"""
    
    return year % 4 == 0 and (year % 100 != 0 or year % 400 == 0)
