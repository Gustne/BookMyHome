﻿using BookMyHome.Application.Command.CommandDto;

namespace BookMyHome.Application.Command;

public interface IRatingCommand
{
    void CreateRating(CreateRatingDto ratingDto);

}