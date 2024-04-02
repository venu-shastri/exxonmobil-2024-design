
# Refactoring legacy code

Legacy code can be complex. It often starts simple, but collects complexity as the product and its customers evolve.

This repository has legacy code in it. Let's refactor to enable evolution without adding complexity.

## About this repository

The objective of the code is to monitor battery temperature and prevent damage:

- Classify the temperature measurement as being too high or too low. This classification depends on the type of cooling. With active cooling, the battery can reach higher temperatures before taking action.
- Transmit the classification to take action: When the system has a controller, send the classification to it. In the absence of a controller, send the classification via email. In this project, the transmission is 'simulated' by printing on the console.

The [GitHub Actions](https://docs.github.com/en/actions) in this project implement several workflows:

- No Duplications: Fails on finding duplication of 3 lines or more. There are no duplications, so this passes.
- Limit complexity: The limit per function is set at 3 and it's currently failing
- Build and Run: Runs the tests. It's passing currently, but there are hardly any tests. You need to add more.
- Enter Reflections: Replace the `_enter` in the **Reflections** section below, within this file. This workflow fails till you replace it with your impressions.

As with any legacy, have a look at the code to understand it better.

This project uses the
[unittest framework](https://docs.python.org/3/library/unittest.html)
to test functionality.

The 'Build and Run' workflow stores coverage-data as an artifact in the workflow run. You can download it from GitHub Actions.

## The refactoring task

Cyclomatic complexity is high in a few places. This indicates potential to steadily increase, as customers ask for changes and new features. Reduce the cyclomatic complexity. In future, it must be possible to add new features with less code-changes and re-testing.

Code coverage is low, because the test code is incomplete. Write more tests to take care of the variations. Track and improve the coverage.

Uncovered lines indicate an opportunity to write tests. Complex and repetitive tests indicate opportunity to simplify the code.

> Caution: High coverage doesn't indicate absence of bugs!


def infer_breach(value, lowerLimit, upperLimit):
  if value < lowerLimit:
    return 'TOO_LOW'
  if value > upperLimit:
    return 'TOO_HIGH'
  return 'NORMAL'


def classify_temperature_breach(coolingType, temperatureInC):
  lowerLimit = 0
  upperLimit = 0
  if coolingType == 'PASSIVE_COOLING':
    lowerLimit = 0
    upperLimit = 35
  elif coolingType == 'HI_ACTIVE_COOLING':
    lowerLimit = 0
    upperLimit = 45
  elif coolingType == 'MED_ACTIVE_COOLING':
    lowerLimit = 0
    upperLimit = 40
  return infer_breach(temperatureInC, lowerLimit, upperLimit)


def check_and_alert(alertTarget, batteryChar, temperatureInC):
  breachType =\
    classify_temperature_breach(batteryChar['coolingType'], temperatureInC)
  if alertTarget == 'TO_CONTROLLER':
    send_to_controller(breachType)
  elif alertTarget == 'TO_EMAIL':
    send_to_email(breachType)


def send_to_controller(breachType):
  header = 0xfeed
  print(f'{header}, {breachType}')


def send_to_email(breachType):
  recepient = "a.b@c.com"
  if breachType == 'TOO_LOW':
    print(f'To: {recepient}')
    print('Hi, the temperature is too low')
  elif breachType == 'TOO_HIGH':
    print(f'To: {recepient}')
    print('Hi, the temperature is too high')
