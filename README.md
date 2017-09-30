# Fork from https://github.com/tpeczek/Demo.AspNetCore.ServerSentEvents

About HTTP2 & SSE
https://www.igvita.com/2013/06/12/innovating-with-http-2.0-server-push/

About HTTP2 & ASP.Net Core
https://www.tpeczek.com/2017/04/http2-with-server-push-proof-of-concept.html
https://dzone.com/articles/http2-with-server-push-proof-of-concept-for-aspnet

Articoli di riferimento:
https://www.tpeczek.com/2017/02/server-sent-events-sse-support-for.html
https://dzone.com/articles/server-sent-events-sse-support-for-aspnet-core

* https://hpbn.co/
* http://caniuse.com/#search=server-sent
* https://www.html5rocks.com/en/tutorials/eventsource/basics/


# Demo.AspNetCore.ServerSentEvents

Application for demonstrating functionality of [Lib.AspNetCore.ServerSentEvents](https://github.com/tpeczek/Lib.AspNetCore.ServerSentEvents).

The application exposes two SSE endpoints:
* `/see-heartbeat` which can be "listened" by navigating to `/sse-heartbeat-receiver.html`. It sends an event every 5s and is implemented through an ugly background thread.
* `/sse-notifications` which can be "listened" by navigating to `/notifications/sse-notifications-receiver`. Sending events to this endpoint can be done by navigating to `/notifications/sse-notifications-sender`.

## Donating

Lib.AspNetCore.ServerSentEvents is a personal open source project. If Lib.AspNetCore.ServerSentEvents has been helpful to you, consider donating. Donating helps support Lib.AspNetCore.ServerSentEvents.

<a href='https://pledgie.com/campaigns/33551'><img alt='Click here to lend your support to: Lib.AspNetCore.ServerSentEvents and make a donation at pledgie.com !' src='https://pledgie.com/campaigns/33551.png?skin_name=chrome' border='0' ></a>

## Copyright and License

Copyright © 2017 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Demo.AspNetCore.ServerSentEvents/blob/master/LICENSE.md)
