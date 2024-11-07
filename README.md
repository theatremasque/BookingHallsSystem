Test task example at position Middle C# .Net developer
"RESTful API Booking halls system"

Technology stack: 
  - ASP.NET Core 8
  - EF Core
  - PostgreSQL
  - AutoMapper
  - FluentValidation
  - Redis
  - NUnit
  - Moq
  - Hangfire
    
Arhitecture and design patterns:
  - DTO
  - CQRS
  - Mediator
  - Dependency Injection
    
Security:
  - JWT-auth
    
Validation:
  - model validation at dto level
    
Tests:
  - Unit


PostgreSQL test in DataGrip

![image](https://github.com/user-attachments/assets/a6e0fc12-5ba1-49e7-bfae-4190de35e19d)

create table halls(
    id serial not null primary key,
    price_per_hour integer not null,
    title text not null,
    description text not null,
    CONSTRAINT price_greater_than_zero CHECK ( price_per_hour > 0 )
);

create table if not exists bookings(
    id serial not null primary key,
    hall_id integer not null references halls (id),
    event_name text not null,
    start_time timestamp not null,
    end_time timestamp not null,
    duration interval not null generated always as (date_trunc('minute', end_time - start_time)) stored,
    cost_price decimal null,
    constraint start_time_greater_than_now_or_equals check (start_time >= now()),
    constraint start_time_minutes_interval check (extract(minute from start_time) in (0, 30)),
    constraint end_time_minutes_interval check (extract(minute from end_time) in (0, 30)),
    constraint end_time_greater_than_start_time check (end_time > start_time),
    constraint minimal_time_of_duration check (duration > interval '30 minutes'),
    constraint start_time_within_booking_hours check (
        extract(hour from  start_time) >= 8 and extract(hour from start_time) <= 23
    ),
    constraint end_time_before_11pm check (
        extract(hour from end_time) < 23 or extract(hour from end_time) = 23 and extract(minute from end_time) = 0
    )
);
