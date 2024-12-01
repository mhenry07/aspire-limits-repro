# AspireLimitsRepro

Reproduction for: https://github.com/dotnet/aspire/issues/6849

GitHub repo: https://github.com/mhenry07/aspire-limits-repro

## Steps To Reproduce

- Run the AppHost project which continually and rapidly generates traces and logs
- From the Aspire dashboard, navigate to the Traces or Structured Logs view
- Wait for the traces or structured log limit to be exceeded (roughly 30 seconds)
- Manually scroll up
- Note that the auto scrolling behavior of the traces or structured logs continues even after manually scrolling up
- Make a mental note of a specific trace or structured log that appears on screen
- Attempt to click on the specific trace or structured log before it scrolls off screen (with the same trace id or timestamp and log message as the one you made a mental note of)
- Note that it is very difficult to click on the intended item before it autoscrolls off screen, and it is very easy to click on a different item that autoscrolled to the same position
